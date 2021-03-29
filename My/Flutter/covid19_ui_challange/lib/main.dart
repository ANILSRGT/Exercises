import 'package:covid19_ui_challange/Screens/splash_screen.dart';
import 'package:flutter/material.dart';

main(List<String> args) {
  runApp(CovidApp());
}

class CovidApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Covid-19 Stats',
      theme: ThemeData(
        primaryColor: Colors.teal,
      ),
      home: SafeArea(child: SplashScreen()),
    );
  }
}
