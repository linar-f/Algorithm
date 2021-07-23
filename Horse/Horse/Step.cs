using System;
using System.Collections.Generic;
using System.Text;

namespace Horse
{
    class Step
    {
        public int line;
        public int column;
        public bool status;
        public Step[] nextSteps = new Step[8];
        public Step prevStep;

        public Step(int _line, int _column)
        {
            line = _line;
            column = _column;
            status = true;
        }

        public void addStep(Step lastStep, int nextLine, int nextColumn, int index)
        {
            Step newStep = new Step(nextLine, nextColumn);
            lastStep.nextSteps[index] = newStep;
            newStep.prevStep = lastStep;
        }
    }
}
