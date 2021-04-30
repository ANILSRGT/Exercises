import 'package:flutter/material.dart';

class CustomTheme {
  static const Color _backgroundColor = Color(0xFFFFFFFF);
  static const Color _primaryColor = Color(0xFFFF7368);
  static const Color _primaryTextColor = Color(0xFF292B2D);
  static const Color _circleAvatarBackgroundColor = Color(0xFFC7E7FF);
  static const Color _verticalListImageBackgroundColor = Color(0xFFFFE4E0);
  static const List<Color> _listBackgroundColors = [
    Color(0xFFFFEAC5),
    Color(0xFFC3E3FF),
    Color(0xFFD7FBD9),
    Color(0xFFFCD7F7),
  ];
  static List<Color> _listForegroundColors = [
    Color(0xFFDC9749), //#DC9749
    Color(0xFF698CAC), //#698CAC
    Color(0xFF51CF79), //#51CF79
    Color(0xFFCE5DBF), //#F8D013
  ];

  static Color get backgroundColor => _backgroundColor;
  static Color get primaryColor => _primaryColor;
  static Color get primaryTextColor => _primaryTextColor;
  static Color get circleAvatarBackgroundColor => _circleAvatarBackgroundColor;
  static Color get verticalListImageBackgroundColor =>
      _verticalListImageBackgroundColor;
  static List<Color> get listBackgroundColors => _listBackgroundColors;
  static List<Color> get listForegroundColors => _listForegroundColors;
}
