
// lerp = linear interpolation

void setup() {
  size(500, 500);
}

void draw() {
  background(128);
  
  
  //clac the stroke weight from mouse position
  float p2 = mouseY / (float)height;
  float w = lerp(1, 50, p2);
  strokeWeight(w);
  
  //calc the percent:
  float p = mouseX / (float)width;
  
  //calc the diameter:
  float d = lerp(50, 500, p); 
  
  //what do we want to draw?
  ellipse(width/2, height/2, d, d);
}
