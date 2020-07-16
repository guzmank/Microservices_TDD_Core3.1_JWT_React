import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { Container } from 'reactstrap';
import AdminNavMenu from '../navMenu/AdminNavMenu';
import '../../node_modules/primereact/resources/primereact.css';
import '../../node_modules/primereact/resources/themes/nova-dark/theme.css';

const AdminLayout = ({ children }) => {
    return (
        <div>
            <AdminNavMenu />
            <Container>
                {children}
            </Container>
        </div>
    )
}

const AdminLayoutRoute = ({ component: Component, ...rest }) => {
    return (
        <Route {...rest} render={props => (
            localStorage.getItem('user')
                ? <AdminLayout><Component {...props} /></AdminLayout>
                : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
        )} />
    )
};

export default AdminLayoutRoute;