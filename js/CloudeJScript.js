function ksAlert(vH, vsms) {
    $('div[id$="AlertCover"]').hide();
    $('div[id$="AlertId"]').hide();
    var vHead = vH;
    var vMsg = vsms;
    var vContainBlock = document.getElementById("AlerContaiBlock");
    var vAlertTyoe = document.getElementById("AlertHead");
    var vAlerMsg = document.getElementById("lblAlertMsg");

    if (vHead == "w") {
        vContainBlock.className = "alert alert-danger";
        vAlertTyoe.innerHTML = "Warning !";
        vAlerMsg.innerHTML = vMsg;

        $('div[id$="AlertCover"]').fadeIn();
        $('div[id$="AlertId"]').animate({
            height: 'toggle'
        });

    }
    else if (vHead == "s") {
        vContainBlock.className = "alert alert-success";
        vAlertTyoe.innerHTML = "Success !";
        vAlerMsg.innerHTML = vMsg;

        $('div[id$="AlertCover"]').fadeIn();
        $('div[id$="AlertId"]').animate({
            height: 'toggle'
        });

    }
    else if (vHead == "i") {
        vContainBlock.className = "alert alert-info";
        vAlertTyoe.innerHTML = "Information !";
        vAlerMsg.innerHTML = vMsg;

        $('div[id$="AlertCover"]').fadeIn();
        $('div[id$="AlertId"]').animate({
            height: 'toggle'
        });
    }

    setTimeout(function () {
       ffirclose();
    }, 3000);

}

function ffirclose() {
    $('div[id$="AlertId"]').animate({
        height: 'toggle'
    });
    $('div[id$="AlertCover"]').fadeOut();
}


function navigateNotification() {
    window.location.href = "Notification.aspx";
}

function DateKeyDown()
{
    return event.keyCode == 9;
}