import * as React from 'react';
import {Component} from 'react';
import {LoginFormValues} from '../LoginPage';
import {FormikActions, Field} from 'formik';
import {Button} from 'react-native';

interface Props {}
type AllProps = Props;
class LoginForm extends Component<AllProps> {
  private passwordInput: any;
  submit = (
    values: LoginFormValues,
    actions: FormikActions<LoginFormValues>,
  ) => {};

  render() {
    return (
      <View>
        <Formik
          onSubmit={this.submit}
          initialValues={{username: '', password: ''}}
          render={(formikBag: FormikProps<LoginFormValues>) => {
            return (
              <>
                <Field
                  setFieldValue={formikBag.setFieldValue}
                  setFieldTouched={formikBag.setFieldTouched}
                  name="username"
                  label={t('loginPage.form.usernameLabel')}
                  component={WhiteTextFieldWithRef}
                  placeholder={t('loginPage.form.usernamePlaceholder')}
                  autoCapitalize="none"
                  autoCorrect={false}
                  clearButtonMode="while-editing"
                  enablesReturnKeyAutomatically
                  textContentType="username"
                  returnKeyType="next"
                  onSubmitEditing={() => {
                    this.passwordInput.refs.password.focus();
                  }}
                  blurOnSubmit={false}
                />
                {/* {refreshTokenFailed && (
                  <ErrorAlert errorCode={'loginPage.errors.expired'} />
                )}
                {submitError && !formikBag.isSubmitting && (
                  <ErrorAlert errorCode={submitError} style={{marginTop: 0}} />
                )} */}

                <Button
                  mode="contained"
                  dark={true}
                  disabled={formikBag.isSubmitting}
                  loading={formikBag.isSubmitting}
                  contentStyle={{paddingVertical: 10}}
                  onPress={formikBag.handleSubmit}>
                  Login
                </Button>
              </>
            );
          }}
        />
      </View>
    );
  }
}
