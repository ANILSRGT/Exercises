import 'package:flutter/material.dart';
import 'package:login_ui/home_page.dart';

class LoginPage extends StatefulWidget {
  static String tag = 'login-page';

  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  @override
  Widget build(BuildContext context) {
    final logo = Hero(
      tag: 'hero',
      child: FlutterLogo(
        size: 48,
      ),
    );

    final email = TextFormField(
      keyboardType: TextInputType.emailAddress,
      autofocus: false,
      decoration: InputDecoration(
        hintText: 'Email',
        contentPadding: EdgeInsets.fromLTRB(20, 10, 20, 10),
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(32),
        ),
      ),
    );

    final password = TextFormField(
      autofocus: false,
      obscureText: true,
      decoration: InputDecoration(
        hintText: 'Password',
        contentPadding: EdgeInsets.fromLTRB(20, 10, 20, 10),
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(32),
        ),
      ),
    );

    final loginButton = Padding(
      padding: EdgeInsets.symmetric(vertical: 16),
      child: GestureDetector(
        onTap: () {
          Navigator.of(context).pushNamed(HomePage.tag);
        },
        child: Container(
          height: 42,
          constraints: BoxConstraints(
            minWidth: 200,
          ),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(30),
            color: Colors.lightBlueAccent,
            boxShadow: [
              BoxShadow(
                color: Colors.lightBlueAccent.shade100,
                offset: Offset(0, 5),
                blurRadius: 8,
              ),
            ],
          ),
          child: Center(
            child: Text(
              'Log In',
              style: TextStyle(color: Colors.white),
            ),
          ),
        ),
      ),
    );

    final forgotLabel = TextButton(
      onPressed: () {},
      child: Text(
        'Forgot Password',
        style: TextStyle(color: Colors.black54),
      ),
    );

    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: ListView(
          shrinkWrap: true,
          padding: EdgeInsets.only(left: 24, right: 24),
          children: [
            logo,
            SizedBox(height: 48),
            email,
            SizedBox(height: 8),
            password,
            SizedBox(height: 24),
            loginButton,
            forgotLabel,
          ],
        ),
      ),
    );
  }
}
