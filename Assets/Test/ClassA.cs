using System;

public class ClassA : CustomBehaviour
{
        private void Start()
        {
                Bind.Value(this);
        }
}