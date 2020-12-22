const uri2 = 'api/TodoItems';
const uri = 'https://app-bnmibanco-v2-0-0-bncr-as.bnenlinea.com/api/ConsultaTipoCambios/Get?pCanal=IBP';
let todos = [];

function obtenerTipoCambio() {  
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
  //alert(data.ventaDolares);  
  document.getElementById('lblCompra').innerHTML = data.compraDolares;
  document.getElementById('lblVenta').innerHTML = data.ventaDolares;
}
