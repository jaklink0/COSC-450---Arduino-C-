//450 project that will use 2 languages 
//our languages will be C# and arduino
//project by Andrew Naylor, Joe in the back, and Joshua Jenkins 
#include <Servo.h>


int redLED= 3; // the pin on the arduino that the red LED is connecte to
int greenLED = 2; //the pin on the arduino that the green Led is connected to
bool lock;

;
Servo lockServo; 
// we will need a method that checks some value from C# program, and changes lock bool value
//this method needs to receive a boolean from the C# program, which was calculated by a user entering a password that matches the one set in the program
bool shouldUnlock(bool unlock){
  if(unlock = true){
    lock = false;
  }else{
    lock = true;
  }
  
}
void setup() {
  
  Serial.begin(9600);// starts the serial that we will communicate with through C#

  // in the setup we will assign the pins 
  pinMode(redLED, OUTPUT);
  pinMode(greenLED, OUTPUT);
  lockServo.attach(4);

}

void loop() {
  //will need to continuoudly check the value returned by the c# program to tell weather to unlock the box, or keep it locked 
  // put your main code here, to run repeatedly:
  if ( shouldLock() == false ){
    lockServo.write(160);
    digitalWrite(redLED,LOW);
    digitalWrite(greenLED,HIGH);
    
  }else{
    lockServo.write(60);
    digitalWrite(redLED,HIGH);
    digitalWrite(greenLED,LOW);

  }
 
}
