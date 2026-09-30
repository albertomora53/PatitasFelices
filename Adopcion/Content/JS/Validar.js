
function validarFormulario(idTelefono, idChkGasto, idChkCompromiso) {

    // 1. Validar Teléfono
    var inputTelefono = document.getElementById(idTelefono);
    var telefono = inputTelefono.value;
    var regexTel = /^\d{10}$/;

    if (!regexTel.test(telefono)) {
        alert("⚠️ Error en el Teléfono:\nDebe contener exactamente 10 números, sin letras ni espacios.");
        return false;
    }

    // 2. Validar Checkbox Gastos
    var chkGasto = document.getElementById(idChkGasto);
    if (!chkGasto.checked) {
        alert("⚠️ Atención:\nDebes aceptar el compromiso de cubrir los gastos veterinarios y de alimentación.");
        return false;
    }

    // 3. Validar Checkbox Compromiso de Vida
    var chkCompromiso = document.getElementById(idChkCompromiso);
    if (!chkCompromiso.checked) {
        alert("⚠️ Atención:\nDebes declarar que la información es verdadera y aceptar el compromiso de por vida.");
        return false;
    }

    // Si todo está bien
    return true;
}