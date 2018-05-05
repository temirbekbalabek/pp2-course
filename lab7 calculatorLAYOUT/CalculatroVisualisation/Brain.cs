using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum States
    {
        Zero,
        AccumulateDigits,
        Compute,
        ComputePending,
        ComputeMonoOperation,
        ShowError
    }

    public delegate void MyDelegate(string msg);

    class Brain
    {
        double value;
        double memoryNum;
        string svalue;
        string currentNum;
        string operation;
        string msgToShow;
        string equation;

        private States state;
        public MyDelegate showMessage;
        public MyDelegate showEquation;
        public MyDelegate change_MS_MC;
        public MyDelegate showMemory;

        string[] all_digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] non_zero_digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] zero_digits = { "0" };

        string[] monoOperations = { "√", "χ²", "1/x", "±" };
        string[] diOperations = { "+", "-", "÷", "×" };
        string[] equals = { "=" };
        string[] separators = { "," };

        string[] Clear = { "C" };
        string[] memoryOp = { "M+", "M-", "MS", "MR", "MC" };

        public Brain()
        {
            changeState(States.Zero);
        }

        public void Process(string msg)
        {
            switch (state)
            {
                case States.Zero:
                    Zero(false, msg);
                    break;
                case States.AccumulateDigits:
                    AccumulateDigits(false, msg);
                    break;
                case States.Compute:
                    Compute(false, msg);
                    break;
                case States.ComputePending:
                    ComputePending(false, msg);
                    break;
                case States.ComputeMonoOperation:
                    ComputeMonoOperation(false, msg);
                    break;
                case States.ShowError:
                    ShowError(false, msg);
                    break;
                default:
                    break;
            }
            showMessage.Invoke(msgToShow);
            showEquation.Invoke(equation);
        }

        private void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                SetNull();
                changeState(States.Zero);
            }

            else
            {
                if (all_digits.Contains(msg))
                {
                    if (zero_digits.Contains(msg))
                    {
                        Zero(true, msg);
                    }
                    else if (non_zero_digits.Contains(msg))
                    {
                        AccumulateDigits(true, msg);
                    }
                }

                else if (monoOperations.Contains(msg))
                {
                    ComputeMonoOperation(true, msg);
                }

                else if (diOperations.Contains(msg))
                {
                    ComputePending(true, msg);
                }
                else if (equals.Contains(msg))
                {
                    Zero(true, msg);
                }
                else if (separators.Contains(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Clear.Contains(msg))
                {
                    Zero(true, msg);
                }
                else if (memoryOp.Contains(msg))
                {
                    Memory(msg);
                }

            }
        }

        private void AccumulateDigits(bool isInput, string msg)
        {
            if (isInput)
            {
                if (separators.Contains(msg) && !currentNum.Contains(msg))
                {
                    currentNum += msg;
                }

                else if (!separators.Contains(msg))
                {
                    if (currentNum == "0")
                    {
                        currentNum = "";
                    }
                    currentNum += msg;
                }
                msgToShow = currentNum;
                changeState(States.AccumulateDigits);
            }

            else
            {
                if (all_digits.Contains(msg))
                {
                    AccumulateDigits(true, msg);
                }

                else if (monoOperations.Contains(msg))
                {
                    ComputeMonoOperation(true, msg);
                }
                else if (diOperations.Contains(msg))
                {
                    ComputePending(true, msg);
                }
                else if (equals.Contains(msg))
                {
                    Compute(true, msg);
                }
                else if (separators.Contains(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Clear.Contains(msg))
                {
                    Zero(true, msg);
                }
                else if (memoryOp.Contains(msg))
                {
                    Memory(msg);
                }

            }
        }

        private void ComputePending(bool isInput, string msg)
        {
            if (isInput)
            {
                if (operation == "")
                {
                    value = double.Parse(currentNum);
                }
                else if (operation == "+")
                {
                    value += double.Parse(currentNum);
                }
                else if (operation == "-")
                {
                    value -= double.Parse(currentNum);
                }
                else if (operation == "×")
                {
                    value *= double.Parse(currentNum);
                }
                else if (operation == "÷")
                {
                    value /= double.Parse(currentNum);
                }

                operation = msg;
                svalue = value.ToString();
                currentNum = "0";
                msgToShow = "0";
                equation = svalue + " " + operation;
                changeState(States.ComputePending);
            }

            else
            {
                if (all_digits.Contains(msg))
                {
                    AccumulateDigits(true, msg);
                }

                else if (monoOperations.Contains(msg))
                {
                    ComputeMonoOperation(true, msg);
                }
                else if (diOperations.Contains(msg))
                {
                    ComputePending(true, msg);
                }
                else if (equals.Contains(msg))
                {

                }
                else if (separators.Contains(msg))
                {

                }
                else if (Clear.Contains(msg))
                {
                    Zero(true, msg);
                }
                else if (memoryOp.Contains(msg))
                {
                    Memory(msg);
                }
            }
        }

        private void ComputeMonoOperation(bool isInput, string msg)
        {
            if (isInput)
            {
                double tempNum = double.Parse(currentNum);
                if (msg == "√")
                {
                    tempNum = Math.Sqrt(tempNum);
                    equation = $"{msg}({currentNum})";
                }
                else if (msg == "χ²")
                {
                    tempNum = Math.Pow(tempNum, 2);
                    equation = $"({currentNum})²";
                }
                else if (msg == "1/x")
                {
                    tempNum = 1 / tempNum;
                    equation = $"1/({currentNum})";

                }
                else if (msg == "±")
                {
                    tempNum = (-1) * tempNum;
                }

                currentNum = tempNum.ToString();
                msgToShow = currentNum;
                changeState(States.ComputeMonoOperation);
            }

            else
            {
                if (all_digits.Contains(msg))
                {
                    SetNull();
                    AccumulateDigits(true, msg);
                }

                else if (monoOperations.Contains(msg))
                {
                    ComputeMonoOperation(true, msg);
                }
                else if (diOperations.Contains(msg))
                {
                    ComputePending(true, msg);
                }
                else if (equals.Contains(msg))
                {
                    Compute(true, msg);
                }
                else if (separators.Contains(msg))
                {

                }
                else if (Clear.Contains(msg))
                {
                    SetNull();
                    Zero(true, msg);
                }
                else if (memoryOp.Contains(msg))
                {
                    Memory(msg);
                }

            }
        }

        private void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                if (operation == "+")
                {
                    value += double.Parse(currentNum);
                }
                else if (operation == "-")
                {
                    value -= double.Parse(currentNum);
                }
                else if (operation == "×")
                {
                    value *= double.Parse(currentNum);
                }
                else if (operation == "÷")
                {
                    value /= double.Parse(currentNum);
                }

                svalue = value.ToString();
                msgToShow = svalue;
                operation = "";
                currentNum = svalue;
                equation = "";
                changeState(States.Compute);

            }

            else
            {
                if (all_digits.Contains(msg))
                {
                    SetNull();
                    AccumulateDigits(true, msg);
                }

                else if (monoOperations.Contains(msg))
                {
                    currentNum = svalue;
                    ComputeMonoOperation(true, msg);
                }
                else if (diOperations.Contains(msg))
                {
                    ComputePending(true, msg);
                }
                else if (equals.Contains(msg))
                {
                    Compute(true, msg);
                }
                else if (separators.Contains(msg))
                {

                }
                else if (Clear.Contains(msg))
                {
                    Zero(true, msg);
                }
                else if (memoryOp.Contains(msg))
                {
                    Memory(msg);
                }
            }
        }


        private void ShowError(bool isInput, string msg)
        {
            if (isInput)
            {

            }

            else
            {
                if (all_digits.Contains(msg))
                {
                    if (zero_digits.Contains(msg))
                    {

                    }
                    else if (non_zero_digits.Contains(msg))
                    {

                    }
                }

                else if (monoOperations.Contains(msg))
                {

                }
                else if (diOperations.Contains(msg))
                {

                }
                else if (equals.Contains(msg))
                {

                }
                else if (separators.Contains(msg))
                {

                }
                else if (Clear.Contains(msg))
                {

                }
                else if (memoryOp.Contains(msg))
                {

                }

            }
        }

        private void Memory(string msg)
        {
            switch (msg)
            {
                case "M+":
                    memoryNum += double.Parse(currentNum);
                    currentNum = "0";
                    msgToShow = currentNum;
                    showMemory.Invoke($"Memory: {memoryNum}");
                    change_MS_MC.Invoke("MC");
                    break;
                case "M-":
                    memoryNum -= double.Parse(currentNum);
                    currentNum = "0";
                    msgToShow = currentNum;
                    showMemory.Invoke($"Memory: {memoryNum}");
                    change_MS_MC.Invoke("MC");
                    break;
                case "MS":
                    memoryNum = double.Parse(currentNum);
                    currentNum = "0";
                    msgToShow = currentNum;
                    change_MS_MC.Invoke("MC");
                    showMemory.Invoke($"Memory: {memoryNum}");
                    break;
                case "MR":
                    currentNum = memoryNum.ToString();
                    msgToShow = currentNum;
                    showMemory.Invoke("");
                    change_MS_MC("MS");
                    memoryNum = 0;
                    break;
                case "MC":
                    memoryNum = 0;
                    showMemory.Invoke("");
                    change_MS_MC("MS");
                    break;
                default:
                    break;
            }
        }

        private void changeState(States newState)
        {
            state = newState;
        }

        public void SetNull()
        {
            value = 0;
            svalue = "0";
            currentNum = "0";
            operation = "";
            msgToShow = "0";
            equation = "";
        }

    }
}
