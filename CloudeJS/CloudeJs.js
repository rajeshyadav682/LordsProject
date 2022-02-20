function NumericTextBox(evt) {
    var charCode = (evt.charCode) ? evt.charCode : ((evt.which) ? evt.which : evt.keyCode);
    if (charCode == 8 || charCode == 9 || //backspace
                    charCode == 46 || //delete
                    charCode == 13)   //enter key
    {
        return true;
    }
    else if (charCode >= 37 && charCode <= 40) //arrow keys
    {
        return true;
    }
    else if (charCode >= 48 && charCode <= 57) //0-9 on key pad
    {
        return true;
    }
    else if (charCode >= 96 && charCode <= 105) //0-9 on num pad
    {
        return true;
    }
    else
        return false;
}

function chkAlert() {

    alert("fire this for checking");
    return false;
}


