import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {
  static String tag = 'home-page';

  @override
  Widget build(BuildContext context) {
    final alucard = Hero(
      tag: 'hero',
      child: Padding(
        padding: EdgeInsets.all(16),
        child: FlutterLogo(
          size: 72,
        ),
      ),
    );

    final welcome = Padding(
      padding: EdgeInsets.all(8),
      child: Text(
        'Welcome Alucard',
        style: TextStyle(
          fontSize: 28,
          color: Colors.white,
        ),
      ),
    );

    final lorem = Padding(
      padding: EdgeInsets.all(8),
      child: Text(
        'Velit ea Lorem nisi nostrud occaecat in officia anim nisi. Consectetur veniam do proident aute culpa Lorem cupidatat ullamco proident aliquip nostrud non eu. Eu aliquip minim dolore ipsum qui.',
        style: TextStyle(
          fontSize: 16,
          color: Colors.white,
        ),
      ),
    );

    final body = Container(
      width: MediaQuery.of(context).size.width,
      padding: EdgeInsets.all(28),
      decoration: BoxDecoration(
        gradient: LinearGradient(
          colors: [
            Colors.blue,
            Colors.lightBlueAccent,
          ],
        ),
      ),
      child: Column(
        children: [alucard, welcome, lorem],
      ),
    );

    return Scaffold(
      body: body,
    );
  }
}
