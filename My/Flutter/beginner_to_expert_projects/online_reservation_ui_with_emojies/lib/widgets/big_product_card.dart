import 'package:flutter/material.dart';
import 'package:online_reservation_ui_with_emojies/theme/custom_theme.dart';
import 'package:palette_generator/palette_generator.dart';

class BigProductCard extends StatelessWidget {
  final int listIndex;
  final Image productImage;
  final String productName;
  final double productPrice;

  const BigProductCard({
    Key key,
    @required this.listIndex,
    @required this.productImage,
    @required this.productName,
    @required this.productPrice,
  }) : super(key: key);

  Future<PaletteGenerator> _imageDominantColor(ImageProvider image) async {
    PaletteGenerator paletteGenerator =
        await PaletteGenerator.fromImageProvider(image);
    return paletteGenerator;
  }

  @override
  Widget build(BuildContext context) {
    return Card(
      color: CustomTheme.listBackgroundColors[listIndex % 4],
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(20),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Expanded(
            flex: 3,
            child: Padding(
              padding: const EdgeInsets.all(18.0),
              child: FittedBox(
                fit: BoxFit.contain,
                child: CircleAvatar(
                  backgroundColor: CustomTheme.backgroundColor,
                  radius: 32,
                  child: FutureBuilder<PaletteGenerator>(
                      future: _imageDominantColor(productImage.image),
                      builder: (context, snapshot) {
                        return Container(
                          decoration: BoxDecoration(
                            boxShadow: [
                              BoxShadow(
                                color: snapshot.hasData
                                    ? snapshot.data.dominantColor.color
                                    : Colors.grey,
                                spreadRadius: -14,
                                blurRadius: 12.0,
                                offset: Offset(0, 14),
                              ),
                            ],
                          ),
                          child: productImage,
                        );
                      }),
                ),
              ),
            ),
          ),
          Expanded(
            flex: 2,
            child: Padding(
              padding: const EdgeInsets.all(18.0),
              child: FittedBox(
                fit: BoxFit.fitWidth,
                child: RichText(
                  textAlign: TextAlign.center,
                  text: TextSpan(children: [
                    TextSpan(
                      text: productName[0].toUpperCase() +
                          productName.substring(1),
                      style: Theme.of(context).textTheme.subtitle2.copyWith(
                            color:
                                CustomTheme.listForegroundColors[listIndex % 4],
                            fontWeight: FontWeight.w600,
                          ),
                    ),
                    TextSpan(
                      text: "\n\$$productPrice",
                      style: Theme.of(context).textTheme.caption.copyWith(
                            color:
                                CustomTheme.listForegroundColors[listIndex % 4],
                            fontWeight: FontWeight.w600,
                          ),
                    ),
                  ]),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
