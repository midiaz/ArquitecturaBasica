import React from 'react';
import { connect } from 'react-redux';

const ListadoClientes = props => (
    <div>
        <h1>Listado de Clientes</h1>
        <p>Se muestra un listado de clientes</p>
        <p>-------Aca iria la tabla de clientes------------</p>
    </div>
);

export default connect()(ListadoClientes);