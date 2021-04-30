import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:online_reservation_ui_with_emojies/theme/custom_theme.dart';

class GridListProductCard extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: LayoutBuilder(
        builder: (context, constraint) {
          return Row(
            children: <Widget>[
              Container(
                width: constraint.maxWidth * 0.2,
                height: constraint.maxWidth * 0.2,
                constraints: BoxConstraints(
                  maxWidth: 100,
                  maxHeight: 100,
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
              SizedBox(width: 18),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Text(
                      'Delicious Hot Dog',
                      style: Theme.of(context).textTheme.subtitle1.copyWith(
                            color:
                                CustomTheme.primaryTextColor.withOpacity(0.7),
                            fontSize: constraint.maxWidth * 0.05,
                            fontWeight: FontWeight.bold,
                          ),
                    ),
                    SizedBox(height: constraint.maxWidth * 0.04),
                    Text(
                      "\$6",
                      style: Theme.of(context).textTheme.subtitle1.copyWith(
                            color: CustomTheme.primaryColor,
                            fontWeight: FontWeight.bold,
                            fontSize: constraint.maxWidth * 0.05,
                          ),
                    ),
                  ],
                ),
              ),
            ],
          );
        },
      ),
    );
  }
}
