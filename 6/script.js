class Calculator {
  constructor(currentOperandTextElement, previousOperandTextElement) {
    this.currentOperandTextElement = currentOperandTextElement;
    this.previousOperandTextElement = previousOperandTextElement;
    this.clear();
  }

  del() {
      this.currentOperand = this.currentOperand.slice(0, -1);
      if(this.currentOperand.slice(-1) === '.' || this.currentOperand.slice(-1) === '-') {
        this.currentOperand = this.currentOperand.slice(0, -1);
      }
  }

  clear() {
    this.currentOperand = "";
    this.previousOperand = "";
    this.operation = undefined;
  }

  appendNumber(number) {
    if (number === "." && this.currentOperand.includes(number)) return;
    this.currentOperand += number;
  }

  chooseOperation(operation) {
    if (this.currentOperand === "") return;
    if (this.previousOperand != "") this.compute();
    this.previousOperand = this.currentOperand;
    this.currentOperand = "";
    this.operation = operation;
    this.previousOperand += operation;
  }

  compute() {
    let computation;
    let current = parseFloat(this.currentOperand);
    let previous = parseFloat(this.previousOperand);
    if (isNaN(current) || isNaN(previous)) return;
    switch (this.operation) {
      case "+":
        computation = previous + current;
        break;
      case "-":
        computation = previous - current;
        break;
      case "×":
        computation = previous * current;
        break;
      case "÷":
        computation = previous / current;
        break;
    }
    this.currentOperand = computation.toString();
    this.previousOperand = "";
  }

  updateDisplay() {
    this.currentOperandTextElement.innerText = this.currentOperand;
    this.previousOperandTextElement.innerText = this.previousOperand;
  }
}

const numberButtons = document.querySelectorAll("[data-number]");
const operationButtons = document.querySelectorAll("[data-operation]");
const equalsButton = document.querySelector("[data-equals]");
const delButton = document.querySelector("[data-del]");
const clearButton = document.querySelector("[data-clear]");
const currentOperand = document.querySelector("[data-current-operand]");
const previousOperand = document.querySelector("[data-previous-operand]");

const calculator = new Calculator(currentOperand, previousOperand);

numberButtons.forEach((button) => {
  button.addEventListener("click", () => {
    calculator.appendNumber(button.innerText);
    calculator.updateDisplay();
  });
});

operationButtons.forEach((button) => {
  button.addEventListener("click", () => {
    calculator.chooseOperation(button.innerText);
    calculator.updateDisplay();
  });
});

equalsButton.addEventListener("click", () => {
  calculator.compute();
  calculator.updateDisplay();
});

delButton.addEventListener("click", () => {
    calculator.del();
    calculator.updateDisplay();
})

clearButton.addEventListener("click", () => {
  calculator.clear();
  calculator.updateDisplay();
});
