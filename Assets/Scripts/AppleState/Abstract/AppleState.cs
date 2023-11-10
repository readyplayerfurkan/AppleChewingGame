using UnityEngine;

public abstract class AppleState
{
   public abstract void ChewApple();
   public abstract void ClickToApple(AppleContext currentClickedApple);
   public abstract void GrowApple();
   public abstract void FallApple();
}

