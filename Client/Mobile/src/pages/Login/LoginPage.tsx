import React, {PureComponent} from 'react';
import {Form, Field, ErrorMessage} from 'formik';
import {View, Text} from 'react-native';

export interface LoginFormValues {
  username: string;
  password: string;
}

export default class Login extends PureComponent {
  render() {
    return <View></View>;
  }
}
