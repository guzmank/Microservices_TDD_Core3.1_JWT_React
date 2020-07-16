import React from 'react';
import { connect } from 'react-redux';

const Test2 = props => (
    <div>
        <h1>Test 2 Admin</h1>
        <p>ADMIN: This is an example of a new simple component...</p>
    </div>
);

export default connect()(Test2);