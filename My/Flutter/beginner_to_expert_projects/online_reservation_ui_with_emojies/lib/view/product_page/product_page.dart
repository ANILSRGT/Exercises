import 'dart:math';

import 'package:flutter/material.dart';
import 'package:online_reservation_ui_with_emojies/widgets/grid_list_product_card.dart';

class ProductPage extends StatefulWidget {
  @override
  _ProductPageState createState() => _ProductPageState();
}

class _ProductPageState extends State<ProductPage> {
  final gridScrollController = ScrollController();
  bool isScroll = false;

  void gridScroll(bool isForward) {
    gridScrollController
        .animateTo(
      isForward
          ? gridScrollController.offset + 30
          : gridScrollController.offset - 30,
      duration: Duration(milliseconds: 100),
      curve: Curves.linear,
    )
        .whenComplete(() {
      if (isScroll) {
        print(gridScrollController.offset.toString() +
            " -- " +
            gridScrollController.position.maxScrollExtent.toString());
        if (gridScrollController.offset <= 0 && !isForward) return;
        if (gridScrollController.offset >=
                gridScrollController.position.maxScrollExtent &&
            isForward) return;
        gridScroll(isForward);
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: CustomScrollView(
        physics: BouncingScrollPhysics(),
        slivers: [
          SliverPadding(
            padding: EdgeInsets.all(18),
            sliver: SliverToBoxAdapter(
              child: Stack(
                children: [
                  Container(
                    height: 200.0,
                    child: GridView.builder(
                      controller: gridScrollController,
                      physics: BouncingScrollPhysics(),
                      scrollDirection: Axis.horizontal,
                      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        childAspectRatio: 0.3,
                        mainAxisSpacing: 10,
                        crossAxisCount: 2,
                      ),
                      itemCount: 20,
                      itemBuilder: (context, index) {
                        return Container(
                          width: 100.0,
                          child: GridListProductCard(),
                        );
                      },
                    ),
                  ),
                  Positioned(
                    left: 0,
                    top: 0,
                    bottom: 0,
                    child: GestureDetector(
                      child: Transform.rotate(
                        angle: pi / 2,
                        child: Icon(
                          Icons.arrow_drop_down_circle_rounded,
                          size: 32,
                          color: Colors.grey.withOpacity(0.8),
                        ),
                      ),
                      onTapDown: (s) {
                        if (gridScrollController.offset <= 0) return;

                        isScroll = true;
                        gridScroll(false);
                      },
                      onTapUp: (s) {
                        isScroll = false;
                      },
                    ),
                  ),
                  Positioned(
                    right: 0,
                    top: 0,
                    bottom: 0,
                    child: GestureDetector(
                      child: Transform.rotate(
                        angle: 3 * pi / 2,
                        child: Icon(
                          Icons.arrow_drop_down_circle_rounded,
                          size: 32,
                          color: Colors.grey.withOpacity(0.8),
                        ),
                      ),
                      onTapDown: (s) {
                        if (gridScrollController.offset >=
                            gridScrollController.position.maxScrollExtent)
                          return;

                        isScroll = true;
                        gridScroll(true);
                      },
                      onTapUp: (s) {
                        isScroll = false;
                      },
                    ),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
