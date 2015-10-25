
private var timer = 0.0;
 var bobbingSpeedWalk = 0.20;
 var bobbingSpeedRun = 0.30;
 var bobbingSpeedCrch = 0.10;
 var bobbingSpeedJump = 0;
 var bobbingAmount = 0.000000000001;
 var midpoint = 1.70;

 function Update () {

    var bobbingSpeed = bobbingSpeedWalk;

    if (Input.GetKey ("left shift") || Input.GetKey ("right shift")){
      bobbingSpeed = bobbingSpeedRun;
    }

    if (Input.GetKey ("c")){
      bobbingSpeed = bobbingSpeedCrch;
    }
    if (Input.GetButton("Jump")) {
      bobbingSpeed = bobbingSpeedJump;
    }

    waveslice = 0.0;
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");
    if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) {
       timer = 0.0;
    }
    else {
       waveslice = Mathf.Sin(timer);
       timer = timer + bobbingSpeed;
       if (timer > Mathf.PI * 2) {
          timer = timer - (Mathf.PI * 2);
       }
    }
    if (waveslice != 0) {
       translateChange = waveslice * bobbingAmount;
       totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
       totalAxes = Mathf.Clamp (totalAxes, 0.0, 1.0);
       translateChange = totalAxes * translateChange;
       transform.localPosition.y = midpoint + translateChange;
    }
    else {
       transform.localPosition.y = midpoint;
    }
 }
