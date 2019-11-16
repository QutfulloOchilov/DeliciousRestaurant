import * as React from 'react';
import {Component} from 'react';
import {LoginFormValues} from '../LoginPage';
import {FormikActions, Field, Formik, FormikProps} from 'formik';
import {View, Text} from 'react-native';
import {Button, TextInput, Provider as PaperProvider} from 'react-native-paper';

interface Props {}
type AllProps = Props;
class LoginForm extends Component<AllProps> {
  render() {
    return (
      <View>
        <View style={{flex: 1, flexDirection: 'column', padding: 20}}>
          <Text>text</Text>
          <TextInput style={{backgroundColor: '#ededed', height: 60}} />
          <Text>text</Text>
          <TextInput style={{backgroundColor: '#ededed', height: 60}} />
          <Button
            icon="camera"
            mode="contained"
            style={{height: 40, backgroundColor: '#1e90ff'}}
            onPress={() => console.log('Pressed')}>
            Press me
          </Button>
        </View>
      </View>
    );
  }
}
export default LoginForm;
