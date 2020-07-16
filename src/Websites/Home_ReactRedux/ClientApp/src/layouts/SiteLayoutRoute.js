import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { Container } from 'reactstrap';
import SiteNavMenu from '../navMenu/SiteNavMenu';
import '../../node_modules/primereact/resources/primereact.css';
import '../../node_modules/primereact/resources/themes/nova-dark/theme.css';

const SiteLayout = ({ children }) => {
    return (
        <div>
            <SiteNavMenu />
            <Container>
                {children}
            </Container>
        </div>
    )
}

const SiteLayoutRoute = ({ component: Component, ...rest }) => {
    return (
        <Route {...rest} render={props => (
            localStorage.getItem('user')
                ? <SiteLayout><Component {...props} /></SiteLayout>
                : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
        )} />
    )
};

export default SiteLayoutRoute;