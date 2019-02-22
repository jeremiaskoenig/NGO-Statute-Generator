function updatePurposeLaymanTranslation() {

    for (var element of document.getElementsByClassName("descriptionDiv")) {
        element.hidden = true;
    }

    var targetElement = document.getElementById("option_" + document.getElementById("purposeSelect").value);
    if (targetElement) {
        targetElement.hidden = false;
    }
}
function fillPurposeDescription(purposes) {

    var selectString = "";
    var descriptionDivsString = "";
    var index = 1;
    for (var purpose of purposes) {
        selectString += "<option value=" + (index) + ">" + purpose.purpose + "</option>"
        descriptionDivsString += "<div class='descriptionDiv' id='option_" + (index++) + "' hidden>" + purpose.laymanTranslations.join(", ") + "</div>"
    }
    console.log(selectString);
    
    document.getElementById("purposeSelect").innerHTML = selectString;
    document.getElementById("purposeDescription").innerHTML = descriptionDivsString;

    updatePurposeLaymanTranslation();
}


function getCategoryDescription() {
    var purposeType = document.getElementById("purposeType").value;
    var purposeFreeText = document.getElementById("purposeFreeText").value;
    console.log(purposeType, purposeFreeText);
    $.ajax({
        type: "POST",
        url: "/Statute/PurposeDescription",
        dataType: "json",
        data: {
            "purposeType": purposeType,
            "purposeFreeText": purposeFreeText
        },
        success: function (result) { fillPurposeDescription(result) },
        error: function () { console.log("test") }
    });
}

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

function hideMembersForQuora() {
    console.log(document.getElementById("quoraOptions"), document.getElementById("quoraOptions").value);
    if (document.getElementById("quoraOptions").value == "1") {
        document.getElementById("membersRequiredForQuora").value = 0;
        document.getElementById("membersRequiredForQuora").hidden = true;
    } else {
        document.getElementById("membersRequiredForQuora").hidden = false;
    }
}

function toggleRepresentation(required) {
    toggleButtons(required, "canBeRepresented", "cannotBeRepresented", "");
}

function toggleMembershipFeeInfo(evt) {
    for (var element of document.getElementsByClassName("feeInfo")) {
        element.hidden = evt.target.checked;
    }
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