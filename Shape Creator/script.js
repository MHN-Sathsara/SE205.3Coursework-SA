// When the shape select changes, show/hide the corresponding parameters input fields
document.getElementById("shapeSelect").addEventListener("change", function () {
  var selectedShape = this.value;
  var parametersDiv = document.getElementById("parameters");

  // Remove any existing parameter input fields
  while (parametersDiv.firstChild) {
    parametersDiv.removeChild(parametersDiv.firstChild);
  }

  // Show the appropriate parameter input fields
  if (selectedShape === "circle") {
    var radiusInput = document.createElement("input");
    radiusInput.type = "number";
    radiusInput.placeholder = "Radius";
    parametersDiv.appendChild(radiusInput);
  } else if (selectedShape === "triangle") {
    var side1Input = document.createElement("input");
    side1Input.type = "number";
    side1Input.placeholder = "Side 1";
    parametersDiv.appendChild(side1Input);

    var side2Input = document.createElement("input");
    side2Input.type = "number";
    side2Input.placeholder = "Side 2";
    parametersDiv.appendChild(side2Input);

    var side3Input = document.createElement("input");
    side3Input.type = "number";
    side3Input.placeholder = "Side 3";
    parametersDiv.appendChild(side3Input);
  } else if (selectedShape === "rectangle") {
    var widthInput = document.createElement("input");
    widthInput.type = "number";
    widthInput.placeholder = "Width";
    parametersDiv.appendChild(widthInput);

    var heightInput = document.createElement("input");
    heightInput.type = "number";
    heightInput.placeholder = "Height";
    parametersDiv.appendChild(heightInput);
  } else if (selectedShape === "braille") {
    var brailleTextInput = document.createElement("input");
    brailleTextInput.type = "text";
    brailleTextInput.placeholder = "Braille Text";
    parametersDiv.appendChild(brailleTextInput);
  }
});

// When the compute button is clicked, compute the necessary dots/liquid
document.getElementById("computeButton").addEventListener("click", function () {
  var selectedShape = document.getElementById("shapeSelect").value;
  var parameters = {};

  // Get the values of the parameter input fields
  if (selectedShape === "circle") {
    parameters.radius = parseFloat(
      document.querySelector("#parameters input:nth-of-type(1)").value
    );
  } else if (selectedShape === "triangle") {
    parameters.side1 = parseFloat(
      document.querySelector("#parameters input:nth-of-type(1)").value
    );
    parameters.side2 = parseFloat(
      document.querySelector("#parameters input:nth-of-type(2)").value
    );
    parameters.side3 = parseFloat(
      document.querySelector("#parameters input:nth-of-type(3)").value
    );
  } else if (selectedShape === "rectangle") {
    parameters.width = parseFloat(
      document.querySelector("#parameters input:nth-of-type(1)").value
    );
    parameters.height = parseFloat(
      document.querySelector("#parameters input:nth-of-type(2)").value
    );
  } else if (selectedShape === "braille") {
    var brailleText = document.querySelector("#parameters input").value;
    var dotCount = 0;

    for (var i = 0; i < brailleText.length; i++) {
      var brailleChar = brailleText.charAt(i);

      if (brailleChar === " " || brailleChar === "\n" || brailleChar === "\t") {
        // Skip whitespace characters
        continue;
      }

      dotCount += getBrailleDotCount(brailleChar);
    }

    parameters.dotCount = dotCount;
  }

  // Send a request to the server to compute the necessary dots/liquid
  // using the selected shape and parameters
  // This code assumes that the server is accessible via the URL "/compute"
  fetch("/compute", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      shape: selectedShape,
      parameters: parameters,
    }),
  })
    .then((response) => {
      if (response.ok) {
        return response.text();
      } else {
        throw new Error("Error in response");
      }
    })
    .then((responseText) => {
      // Display the results
      document.getElementById("results").textContent = responseText;
    })
    .catch((error) => {
      console.error("Error:", error);
    });
});

// Returns the number of dots required to represent the given braille character
function getBrailleDotCount(brailleChar) {
  // Define an object that maps each Braille character to the number of dots it uses
  var brailleMap = {
    " ": 0,
    a: 1,
    b: 2,
    c: 3,
    d: 4,
    e: 5,
    f: 6,
    g: 7,
    h: 8,
    i: 9,
    j: 10,
    k: 11,
    l: 12,
    m: 13,
    n: 14,
    o: 15,
    p: 16,
    q: 17,
    r: 18,
    s: 19,
    t: 20,
    u: 21,
    v: 22,
    w: 23,
    x: 24,
    y: 25,
    z: 26,
  };

  // Convert the Braille character to lowercase
  brailleChar = brailleChar.toLowerCase();

  // Return the number of dots used by the Braille character, or null if the character is not in the map
  return brailleMap.hasOwnProperty(brailleChar)
    ? brailleMap[brailleChar]
    : null;
}
