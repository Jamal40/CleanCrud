var issues = "";
getAllIssues = async () => {
  var response = await fetch("https://localhost:7252/api/Issues");
  var issuesData = await response.json();
  console.log(issuesData);

  for (let issue of issuesData) {
    const wrapperDiv = document.createElement("div");
    const label = document.createElement("label");
    const input = document.createElement("input");
    input.type = "checkbox";
    input.value = issue.id;
    label.textContent = issue.name;
    wrapperDiv.append(input);
    wrapperDiv.append(label);
    document.querySelector(".main").append(wrapperDiv);
  }
};

const button = document.querySelector("button");
button.addEventListener("click", async function () {
  const allCheckBoxes = document.querySelectorAll("input[type='checkbox']");
  for (let input of allCheckBoxes) {
    if (input.checked) {
      issues += input.value + ",";
    }
  }
  await addPatient();
});

addPatient = async () => {
  var patientName = document.querySelectorAll("input[name='name']").value;

  var patientObj = {
    name: patientName,
    issuesIds: issues,
  };

  var response = await fetch("https://localhost:7252/api/Patients", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(patientObj),
  });

  console.log(response);
};

getAllIssues();
