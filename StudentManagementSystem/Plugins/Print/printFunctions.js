function printElement(elem, id) {
    var domClone = elem.cloneNode(true);

    var $printSection = document.getElementById(id);
    $("#" + id).addClass('currentPrintSection');

    if (!$printSection) {
         $printSection = document.createElement("div");
        $printSection.id = "printSection";
        document.body.appendChild($printSection);
    }

    $printSection.innerHTML = "";
    $printSection.appendChild(domClone);
    window.print();
    $("#" + id).removeClass('currentPrintSection');
}

function printdiv(printpage) {
    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var newstr = document.all.item(printpage).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + newstr + footstr;
    window.print();
    document.body.innerHTML = oldstr;
    return false;
}

/*--This JavaScript method for Print command--*/
function PrintDoc() {
    var toPrint = document.getElementById('printarea');
    var popupWin = window.open('', '_blank', 'width=350,height=150,location=no,left=200px');
    popupWin.document.open();
    popupWin.document.write('<html><title>::Preview::</title><link rel="stylesheet" type="text/css" href="print.css" /></head><body onload="window.print()">');
    popupWin.document.write(toPrint.innerHTML);
    popupWin.document.write('</html>');
    popupWin.document.close();
}
/*--This JavaScript method for Print Preview command--*/
function PrintPreview() {
    var toPrint = document.getElementById('printarea');
    var popupWin = window.open('', '_blank', 'width=350,height=150,location=no,left=200px');
    popupWin.document.open();
    popupWin.document.write('<html><title>::Print Preview::</title><link rel="stylesheet" type="text/css" href="Print.css" media="screen"/></head><body">');
    popupWin.document.write(toPrint.innerHTML);
    popupWin.document.write('</html>');
    popupWin.document.close();
}


function printMe(id) {
    printElement(document.getElementById(id), id);
    return false;
}

