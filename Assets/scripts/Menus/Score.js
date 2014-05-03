var score1 : GUIText;

var myScore : int = 0;
var maxScore : int = 100000000000;

function Update () {


score1.text = "Score: " + myScore;


if(myScore < maxScore) {

myScore += 10;


}



if(Input.GetKeyDown("b")) {


maxScore += 100;



}





}