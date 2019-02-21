// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleFounderRows() {
    var founderCount = parseInt(document.getElementById("founderCount").value);
    for (var i = 1; i <= 10; i++) {
        var row = document.getElementById("founderRow_" + i.toString());
        if (row && i > founderCount) {
            row.disabled = true;
            row.hidden = true;
        } else if (row && i <= founderCount) {
            row.hidden = false;
        }
    }
}

function toggleRepresentation(required) {
    toggleButtons(required, "canBeRepresented", "cannotBeRepresented", "");
}

function toggleMembershipFeeInfo(required) {
    toggleButtons(required, "feeRequired", "feeNotRequired", "feeInfo");
}

function toggleButtons(required, buttonName1, buttonName2, rowName) {
    var yesButton = document.getElementById(buttonName1);
    var noButton = document.getElementById(buttonName2);
    var row = document.getElementById(rowName);
    if (required) {
        yesButton.setAttribute("checked", "true");
        noButton.removeAttribute("checked");
        if (row) { row.hidden = false };
    } else {
        yesButton.removeAttribute("checked");
        noButton.setAttribute("checked", "true");
        if (row) { row.hidden = true };
    }
}

function reassignPersons() {
    var personTypes = [];
    var checkBoxes = document.getElementsByClassName(personTypes_checkbox);
    for (var checkBox of checkBoxes) {
        if (checkBox.checked) {
            personTypes.push(checkBox.value);
        }
    }
    console.log(personTypes);
}