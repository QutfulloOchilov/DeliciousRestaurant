import * as React from 'react';
import {Component} from 'react';
import {LoginFormValues} from '../LoginPage';
import {FormikActions, Field, Formik, FormikProps} from 'formik';
import {Button, View, TextInput, Text} from 'react-native';

interface Props {}
type AllProps = Props;
class LoginForm extends Component<AllProps> {
  render() {
    return (
      <View>
        <View
          style={{
            flex: 1,
          }}>
          <Text>text</Text>
          <TextInput style={{backgroundColor: '#ededed', height: 60}} />
          <Text>text</Text>
          <TextInput style={{backgroundColor: '#ededed', height: 60}} />
        </View>
      </View>
    );
  }
}
export default LoginForm;
