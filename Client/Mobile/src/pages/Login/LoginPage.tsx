import React, {PureComponent} from 'react';
import {Form, Field, ErrorMessage} from 'formik';
import {View, Text} from 'react-native';
import LoginForm from './components/LoginForm';

export interface LoginFormValues {
  username: string;
  password: string;
}

export default class LoginPage extends PureComponent {
  render() {
    return <LoginForm></LoginForm>;
  }
}
