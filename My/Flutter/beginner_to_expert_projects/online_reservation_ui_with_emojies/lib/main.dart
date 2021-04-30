import 'package:flutter/material.dart';
import 'package:online_reservation_ui_with_emojies/view/home/home_page.dart';

void main() => runApp(EmojiReservationApp());

class EmojiReservationApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Online Reservation With Emojies',
      home: Container(
        color: Colors.black,
        height: 200,
        width: 200,
      ),
    );
  }
}
