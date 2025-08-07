const mostrarSenha = document.getElementById("mostrarSenha");
const senha = document.getElementById("password");

mostrarSenha.addEventListener('change', function () {
    senha.type = this.checked ? "text" : "password";
});