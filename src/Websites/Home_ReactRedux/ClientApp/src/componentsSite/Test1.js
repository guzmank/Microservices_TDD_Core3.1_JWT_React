import React from 'react';
import { connect } from 'react-redux';

const Test1 = props => (
    <div>
        <h1>Test 1</h1>
        <p>This is an example of a new simple component...</p>
    </div>
);

export default connect()(Test1);