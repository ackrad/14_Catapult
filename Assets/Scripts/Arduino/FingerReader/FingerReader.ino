void setup() {
  // put your setup code here, to run once:

Serial.begin(9600);

}

void loop() {
  // put your main code here, to run repeatedly:

  
  int sensorValue1 = 51 + ((analogRead(A0)/4-50)* (300/256));
  int sensorValue2 = 125 + ((analogRead(A1)/4-112)* (300/256));

  //Serial.print(analogRead(A0)/4);
  //Serial.print(",");
  //Serial.println(analogRead(A1)/4);
  
  Serial.print(sensorValue1);
  Serial.print(",");
  Serial.println(sensorValue2);
  //Serial.println("----------------------------------------------");
  delay(30);
  

}
