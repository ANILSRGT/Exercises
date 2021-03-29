import 'package:covid19_ui_challange/Screens/landing_screen.dart';
import 'package:flutter/material.dart';

class SplashScreen extends StatefulWidget {
  @override
  _SplashScreenState createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> with TickerProviderStateMixin {
  AnimationController _controller;

  @override
  void initState() {
    super.initState();
    _controller = AnimationController(duration: Duration(seconds: 4), vsync: this)
      ..forward()
      ..addStatusListener((status) {
        if (status == AnimationStatus.completed) {
          Navigator.of(context)
              .pushAndRemoveUntil(MaterialPageRoute(builder: (ctx) => LandingScreen()), (route) => false);
        }
      });
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: Colors.white.withOpacity(0.9),
        appBar: AppBar(
          elevation: 0,
          backgroundColor: Colors.transparent,
          title: Text(
            'Covid 19 Stats',
            style: TextStyle(
              color: Colors.black,
              fontSize: 32,
            ),
          ),
          centerTitle: true,
        ),
        body: Container(
          width: double.infinity,
          height: double.infinity,
          child: Center(
            child: AnimatedBuilder(
              animation: _controller,
              child: Container(
                width: 50.0,
                height: 50.0,
                child: Image(
                  image: AssetImage("assets/images/virus.png"),
                ),
              ),
              builder: (BuildContext context, Widget child) {
                return Transform.scale(
                  scale: (_controller.value + 3),
                  child: child,
                );
              },
            ),
          ),
        ),
      ),
    );
  }
}
