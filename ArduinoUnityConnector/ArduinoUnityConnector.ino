#include <SerialCommand.h>
#include <SoftwareSerial.h>

SerialCommand sCmd;
const int buttonPin = 2;     // the number of the pushbutton pin

int buttonState = 0;         // variable for reading the pushbutton status
bool isPressed = false;

int photoRPin = 0; 
int minLight;          //Used to calibrate the readings
int maxLight;          //Used to calibrate the readings
int lightLevel;
int adjustedLightLevel;

void setup() {
  Serial.begin(9600);
  while (!Serial);
  //pinMode(buttonPin, INPUT);
  //Setup the starting light level limits
   lightLevel=analogRead(photoRPin);
   minLight=lightLevel-20;
   maxLight=lightLevel;
  //sCmd.addCommand("PING", pingHandler);
  sCmd.addCommand("ECHO", echoHandler);
  sCmd.addDefaultHandler(errorHandler);
}

void loop() {

  // Your operations here
  if (Serial.available() > 0)
    sCmd.readSerial();

 /* buttonState = digitalRead(buttonPin);
  if (buttonState == HIGH) {
      // turn LED on:
      if(!isPressed)  {
        Serial.println("PONG");
        isPressed = true;
      }
    } else {
      isPressed = false;
      // turn LED off:
      //Serial.println("Apagado");
    }  
  delay(50);*/
    //auto-adjust the minimum and maximum limits in real time
    lightLevel=analogRead(photoRPin);
    if(minLight>lightLevel){
    minLight=lightLevel;
    }
    if(maxLight<lightLevel){
    maxLight=lightLevel;
    }
    
    //Adjust the light level to produce a result between 0 and 100.
    adjustedLightLevel = map(lightLevel, minLight, maxLight, 0, 100); 
    
    //Send the adjusted Light level result to Serial port (processing)
    Serial.println(adjustedLightLevel);
    
    //slow down the transmission for effective Serial communication.
    delay(50);
}

void pingHandler ()
{
  Serial.println("PONG");
}

void echoHandler ()
{
  char *arg;
  arg = sCmd.next();
  if (arg != NULL)
    Serial.println(arg);
  else
    Serial.println("nothing to echo");
}

void errorHandler ()
{
  Serial.println("Error Error!!!");
  // Error handling
}
