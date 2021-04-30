import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:online_reservation_ui_with_emojies/theme/custom_theme.dart';

class VerticalListProductCard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Row(
      children: <Widget>[
        Container(
          width: MediaQuery.of(context).size.width * 0.175,
          height: MediaQuery.of(context).size.width * 0.175,
          constraints: BoxConstraints(
            maxWidth: 80,
            maxHeight: 80,
          ),
          decoration: BoxDecoration(
            color: CustomTheme.verticalListImageBackgroundColor,
            borderRadius: BorderRadius.circular(8),
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.4),
                offset: const Offset(0, 14),
                blurRadius: 10,
                spreadRadius: -5,
              ),
            ],
          ),
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Image.asset(
              'assets/images/hot_dog_48px.png',
              fit: BoxFit.contain,
            ),
          ),
        ),
        SizedBox(width: 10),
        Expanded(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Text(
                'Delicious Hot Dog',
                style: Theme.of(context).textTheme.subtitle1.copyWith(
                      color: CustomTheme.primaryTextColor.withOpacity(0.7),
                      fontWeight: FontWeight.bold,
                    ),
              ),
              Row(
                children: [
                  for (var i = 0; i < 5; i++)
                    Icon(
                      Icons.star_rounded,
                      color: Colors.yellow,
                      size: MediaQuery.of(context).size.width * 0.175 / 3,
                    ),
                ],
              ),
              RichText(
                text: TextSpan(
                  children: [
                    TextSpan(
                      text: "\$6",
                      style: Theme.of(context).textTheme.bodyText2.copyWith(
                            color: CustomTheme.primaryColor,
                            fontWeight: FontWeight.bold,
                          ),
                    ),
                    TextSpan(
                      text: "\t\$18",
                      style: Theme.of(context).textTheme.overline.copyWith(
                            decoration: TextDecoration.lineThrough,
                            color: Colors.grey.shade400,
                            fontWeight: FontWeight.bold,
                          ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
        Container(
          decoration: BoxDecoration(
            shape: BoxShape.circle,
            boxShadow: [
              BoxShadow(
                color: CustomTheme.primaryColor.withOpacity(0.4),
                offset: const Offset(0, 10),
                blurRadius: 10,
                spreadRadius: -5,
              ),
            ],
          ),
          child: Icon(
            Icons.add_circle_outlined,
            color: CustomTheme.primaryColor,
            size: MediaQuery.of(context).size.width > 500
                ? 62
                : MediaQuery.of(context).size.width * 0.125,
          ),
        ),
      ],
    );
  }
}
