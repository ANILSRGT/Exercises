import 'package:flutter/material.dart';

class StatsWidget extends StatelessWidget {
  final String yourCity;
  final int testCount;
  final int patientCount;
  final int infectedCount;
  final int deathCount;
  final int healingCount;
  final int caseCount;

  const StatsWidget({
    Key key,
    @required this.yourCity,
    @required this.testCount,
    @required this.patientCount,
    @required this.infectedCount,
    @required this.deathCount,
    @required this.healingCount,
    @required this.caseCount,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(
          yourCity,
          textAlign: TextAlign.center,
          style: TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 32,
          ),
        ),
        SizedBox(height: 15),
        _covidStatWidget(title: 'Test', count: testCount),
        SizedBox(height: 5),
        _covidStatWidget(title: 'Vaka', count: caseCount),
        SizedBox(height: 5),
        _covidStatWidget(title: 'Hasta', count: patientCount),
        SizedBox(height: 5),
        _covidStatWidget(title: 'Enfekte', count: infectedCount),
        SizedBox(height: 5),
        _covidStatWidget(title: 'Vefat', count: deathCount),
        SizedBox(height: 5),
        _covidStatWidget(title: 'İyileşen', count: healingCount),
      ],
    );
  }

  Widget _covidStatWidget({String title, int count}) {
    return Container(
      padding: EdgeInsets.all(10),
      width: double.infinity,
      decoration: BoxDecoration(
        color: Colors.grey.shade200,
        borderRadius: BorderRadius.circular(16),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            title,
            style: TextStyle(
              fontWeight: FontWeight.bold,
              fontSize: 28,
            ),
          ),
          Text(
            '$count',
            style: TextStyle(
              fontWeight: FontWeight.bold,
              color: Colors.blueGrey.shade500,
              fontSize: 23,
            ),
          ),
        ],
      ),
    );
  }
}
