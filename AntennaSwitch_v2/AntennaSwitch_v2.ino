/*
 * AntennaSwitch sketch for Arduino by UB3APP
 * version: 2.0
 * 2017-09-19
 * 
 * управление реле антенного переключателя
 * скетч читает значение кнопок на пинах 2..7 и в соответствии включает реле на пинах 8..13
 * состояние записывается в EEPROM
 * также вместо кнопок можно использовать COM порт для переключения реле
 */
#include <EEPROM.h>

const int btnPinA1  = 2;                      // пин к которому подключена кнопка входа (антенна 1)
const int btnPinA2  = 3;                      // пин к которому подключена кнопка входа (антенна 2)
const int btnPinA3  = 5;                      // пин к которому подключена кнопка входа (антенна 3)
const int btnPinA4  = 6;                      // пин к которому подключена кнопка входа (антенна 4)
const int btnPinA5  = 7;                      // пин к которому подключена кнопка входа (антенна 5)
const int btnPinOut = 4;                      // пин к которому подключена кнопка выхода (трансивер)

const int relayPinA1  = 8;                    // пин к которому подключено реле антенны 1
const int relayPinA2  = 9;                    // пин к которому подключено реле антенны 2
const int relayPinA3  = A3;                   // пин к которому подключено реле антенны 3
const int relayPinA4  = A4;                   // пин к которому подключено реле антенны 4
const int relayPinA5  = A5;                   // пин к которому подключено реле антенны 5
const int relayPinOut = 10;                   // пин к которому подключено реле выхода (трансивер)

const byte maskA1  = B100000;                 // маска, в каком бите хранится состояние антенны 1
const byte maskA2  = B010000;                 // маска, в каком бите хранится состояние антенны 2
const byte maskA3  = B001000;                 // маска, в каком бите хранится состояние антенны 3
const byte maskA4  = B000100;                 // маска, в каком бите хранится состояние антенны 4
const byte maskA5  = B000010;                 // маска, в каком бите хранится состояние антенны 5
const byte maskOut = B000001;                 // маска, в каком бите хранится состояние выхода

const byte powerPwmPin = 11;                  // пин управления питанием реле через ШИМ

const char magicString[] = "AS_STATE";        // уникальная строка для отображения состояния в serial, GUI будет искать эту строку и значение вместе с ней

const byte rom_address = 0;                   // адрес в EEPROM для записи и чтения состояния
byte rom_value = 0;                           // переменная для чтения состояния из EEPROM

byte state         = B000000;                 // переменная для хранения текущего состояния
byte statePrev     = B000000;                 // переменная для хранения предыдущего состояния
byte stateAntPrev  = B000000;                 // переменная для хранения предыдущего состояния включенного входа антенны, при отключении всех антенн

int incomingByte   = 0;                       // переменная для чтения значения из serial 

void setup() {
  Serial.begin(9600);                         // инициализируем serial
  Serial.setTimeout(50);                      // устанавливаем таймаут для того чтобы не ждать долго считывания данных из serial ускоряет управление из GUI
  Serial.println("Antenna Switch by UB3APP initialized...");
  
  pinMode(btnPinA1,  INPUT);                  // пины кнопок в режим INPUT
  pinMode(btnPinA2,  INPUT);
  pinMode(btnPinA3,  INPUT);
  pinMode(btnPinA4,  INPUT);
  pinMode(btnPinA5,  INPUT);
  pinMode(btnPinOut, INPUT);

  digitalWrite(btnPinA1,  HIGH);              // пины кнопок pullup
  digitalWrite(btnPinA2,  HIGH);
  digitalWrite(btnPinA3,  HIGH);
  digitalWrite(btnPinA4,  HIGH);
  digitalWrite(btnPinA5,  HIGH);
  digitalWrite(btnPinOut, HIGH);

  pinMode(relayPinA1,  OUTPUT);               // пины реле в режим OUTPUT
  pinMode(relayPinA2,  OUTPUT);
  pinMode(relayPinA3,  OUTPUT);
  pinMode(relayPinA4,  OUTPUT);
  pinMode(relayPinA5,  OUTPUT);
  pinMode(relayPinOut, OUTPUT);

  pinMode(powerPwmPin, OUTPUT);               // пин ШИМ в режим OUTPUT

  relayOff();                                 // выключаем все реле

  Serial.print("Read EEPROM...");
  rom_value = EEPROM.read(rom_address);       // читаем значение состояния из EEPROM

  if (                                        // проверяем, что значение из EEPROM соответствует одной из масок
    (rom_value == maskA1 | maskOut) ||
    (rom_value == maskA2 | maskOut) ||
    (rom_value == maskA3 | maskOut) ||
    (rom_value == maskA4 | maskOut) ||
    (rom_value == maskA5 | maskOut) ||
    (rom_value == 0)
    ) {
    state = rom_value;                        // записываем в state значение из EEPROM
    Serial.print("\tEEPROM value:");
    Serial.println(rom_value, DEC);
    antSwitch();                              // запускаем функцию переключения антенн 
  } else {                                    // если значение в EEPROM не соответствует ни одной маске
    Serial.print("\tEEPROM value wrong!");
    Serial.print("\tEEPROM value:");
    Serial.println(rom_value, DEC);
    printMagicString(state);                  // выводим текущее состояние 
  }
}

void printMagicString(int _state) {           // функция вывода строки состояния для GUI
  Serial.print(magicString);                  // выводим специально сформированную строку с текущим состоянием для GUI
  Serial.print(":");                          // пример вывода данной функции AS_STATE:17
  Serial.println(_state, DEC);                // GUI будет парсить эту строку читая serial 
}

void relaySwitch() {                          // функция переключает реле в зависимости от значения state
  if ( state > 0 ) {                          // если хоть одно реле надо включить то
    analogWrite(powerPwmPin, 255);            // поднимаем напряжение до напряжения срабатывания реле
    delay(50);
  }
  
  Serial.print("A1:");
  if ( state & maskA1 ) {                     // если в state есть первого входа
    digitalWrite(relayPinA1, HIGH);           // то включаем его
    Serial.print(1);
  } else {                                    // иначе
    digitalWrite(relayPinA1, LOW);            // выключаем
    Serial.print(0);
  }

  Serial.print("\tA2:");                      // повторяем для остальных входов 
  if ( state & maskA2 ) {
    digitalWrite(relayPinA2, HIGH);
    Serial.print(1);
  } else {
    digitalWrite(relayPinA2, LOW);
    Serial.print(0);
  }

  Serial.print("\tA3:");                      // повторяем для остальных входов 
  if ( state & maskA3 ) {
    digitalWrite(relayPinA3, HIGH);
    Serial.print(1);
  } else {
    digitalWrite(relayPinA3, LOW);
    Serial.print(0);
  }

  Serial.print("\tA4:");                      // повторяем для остальных входов 
  if ( state & maskA4 ) {
    digitalWrite(relayPinA4, HIGH);
    Serial.print(1);
  } else {
    digitalWrite(relayPinA4, LOW);
    Serial.print(0);
  }

  Serial.print("\tA5:");                      // повторяем для остальных входов 
  if ( state & maskA5 ) {
    digitalWrite(relayPinA5, HIGH);
    Serial.print(1);
  } else {
    digitalWrite(relayPinA5, LOW);
    Serial.print(0);
  }

  Serial.print("\tOUT:");
  if ( state & maskOut ) {                    // и такой же алгоритм для выхода 
    digitalWrite(relayPinOut, HIGH);
    Serial.print(1);
  } else {
    digitalWrite(relayPinOut, LOW);
    Serial.print(0);
  }
  Serial.println("");

  delay(100);
  analogWrite(powerPwmPin, 40);               // после того как реле сработало, опускаем напряжение, чуть выше чем напряжение отпускания
}

void relayOff() {                             // функция выключает все реле 
  digitalWrite(relayPinA1, LOW);
  digitalWrite(relayPinA2, LOW);
  digitalWrite(relayPinA3, LOW);
  digitalWrite(relayPinA4, LOW);
  digitalWrite(relayPinA5, LOW);
  digitalWrite(relayPinOut, LOW);
}

void antSwitch() {
  if ( state == statePrev ) return;           // выходим если изменений не произошло

  byte stateChg = state ^ statePrev;          // сравниваем текущий статус с предыдущим через XOR (определим какой поменялся бит)
  byte stateOut = bitRead(state, 0);          // считаем состояние выхода (младший бит)

  Serial.print("State: ");
  Serial.print(state, BIN);
  Serial.print("\tPrevState: ");
  Serial.print(statePrev, BIN);
  Serial.print("\tStateChg: ");
  Serial.print(stateChg, BIN);
  Serial.print("\tStateOut: ");
  Serial.print(stateOut, BIN);

  if ( stateChg == maskOut ) {                // если измененный бит это бит выхода (младший бит)
    if (stateOut == 0) {                      // если выход выключили (перевели на эквивалент нагрузки)
      stateAntPrev = ~maskOut & state;        // то запоминаем какая антенна была включена (отрицание маски выхода B000001 вернет B111110, а в state есть состояние включенной антенны)
      state = 0;                              // и выключаем все антенны (переключаем на землю)
    } else {                                  // если выход включили (сняли с эквивалента и подключили к антенне)
      state = stateAntPrev | maskOut;         // то берем запомненное значение включенной антенны и включаем выход
      if (stateAntPrev == 0) {                // но если нет предыдущего состояния включенной антенны
        state = 0;                            // то не выходим из режима эквивалента нагрузки
      }
    }
  } else {                                    // если измененный бит это биты входов (любой бит кроме младшего)
    state = stateChg | maskOut;               // то в переменной stateChg установлен бит включаемого входа, и маска выхода через оператор OR включают необходимую антенну и выход
  }
  
  Serial.print("\tStateAntPrev: ");
  Serial.print(stateAntPrev, BIN);
  Serial.print("\tStateModified: ");
  Serial.println(state, BIN);

  if ( rom_value != state ) {                 // если считаное значение из EEPROM отличается от текущего запишем его в EEPROM
    Serial.println("Write EEPROM...");
    EEPROM.write(rom_address, state);         // сохраняем значение состояния в EEPROM
    rom_value = state;                        // и запишем в rom_value текущее состояние 
  }
  
  relaySwitch();                              // переключаем реле в соответствии со state
  
  printMagicString(state);                    // записываем в serial значение текущего состояния для GUI
  
  statePrev = state;                          // записываем текущее состояние в предыдущее
}

void btnDelay() {                             // задержка от дребезга кнопок
  delay(300);
}

void loop() {
  if ( digitalRead(btnPinA1) == LOW ) {      // считываем значение кнопки 1
    state = state | maskA1;                   // повторное нажатие на кнопку входа ни к чему не приводит, используем ИЛИ
    btnDelay();                               // задержка для предотвращения дребезга
  }
  if ( digitalRead(btnPinA2) == LOW ) {      // считываем значение кнопки 2
    state = state | maskA2;                   // повторное нажатие на кнопку входа ни к чему не приводит, используем ИЛИ
    btnDelay();                               // задержка для предотвращения дребезга
  }
  if ( digitalRead(btnPinA3) == LOW ) {      // считываем значение кнопки 3
    state = state | maskA3;                   // повторное нажатие на кнопку входа ни к чему не приводит, используем ИЛИ
    btnDelay();                               // задержка для предотвращения дребезга
  }
  if ( digitalRead(btnPinA4) == LOW ) {      // считываем значение кнопки 4
    state = state | maskA4;                   // повторное нажатие на кнопку входа ни к чему не приводит, используем ИЛИ
    btnDelay();                               // задержка для предотвращения дребезга
  }
  if ( digitalRead(btnPinA5) == LOW ) {      // считываем значение кнопки 5
    state = state | maskA5;                   // повторное нажатие на кнопку входа ни к чему не приводит, используем ИЛИ
    btnDelay();                               // задержка для предотвращения дребезга
  }
  if ( digitalRead(btnPinOut) == LOW ) {     // считываем значение кнопки выхода
    state = state ^ maskOut;                  // повторное нажатие на кнопку выхода переключает его состояние: антенна или эквивалент (используем исключающие ИЛИ)
    btnDelay();                               // задержка для предотвращения дребезга
  }

  if (Serial.available() > 0) {               // читаем serial, возможно управление через GUI
    incomingByte = Serial.parseInt();         // читаем значение state из serial
    Serial.print("Received from serial: ");   // и выводим это значение
    Serial.print(incomingByte, DEC);
    Serial.print("\t(0x");
    Serial.print(incomingByte, BIN);
    Serial.println(")");
    if (                                      // проверим, что значение state которое, пришло из serial соответствует одной из маски входов
      incomingByte == maskA1 ||               // переключать состояние входа из serial / GUI нельзя
      incomingByte == maskA2 ||
      incomingByte == maskA3 ||
      incomingByte == maskA4 ||
      incomingByte == maskA5
      ) {
        state = state | incomingByte;         // установим значение state значением из serial 
      } else {
        printMagicString(state);              // если значение из serial не соответствует маске, просто выводим текущее состояние 
      }
  }
  
  antSwitch();                                // запускаем функцию переключения антенн 
  delay(10);
}
