import React from 'react';
import { Route } from 'react-router-dom';

import Login from './login/Login';

/** Layouts **/
import SiteLayoutRoute from "./layouts/SiteLayoutRoute";
import AdminLayoutRoute from "./layouts/AdminLayoutRoute";
import MainLayout from './layouts/MainLayout';

/** Components SITE **/
import Home from './componentsSite/Home';
import Counter from './componentsSite/Counter';
import FetchData from './componentsSite/FetchData';
import ContactList from './componentsSite/ContactList';
import Test1 from './componentsSite/Test1';

/** Components ADMIN **/
import Test2 from './componentsAdmin/Test2';


export default () => (
    <MainLayout>
        <SiteLayoutRoute exact path='/' component={Home} />
        <SiteLayoutRoute exact path='/counter' component={Counter} />
        <SiteLayoutRoute exact path='/fetch-data/:startDateIndex?' component={FetchData} />
        <SiteLayoutRoute exact path='/contacts' component={ContactList} />
        <SiteLayoutRoute exact path='/test1' component={Test1} />

        <AdminLayoutRoute exact path='/administration/test2' component={Test2} />

        <Route path='/login' component={Login} />
    </MainLayout>
);
