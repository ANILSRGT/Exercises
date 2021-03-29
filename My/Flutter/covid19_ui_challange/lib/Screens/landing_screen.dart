import 'dart:convert';
import 'package:covid19_ui_challange/Services/covidapi_service.dart';
import 'package:covid19_ui_challange/Widgets/stats_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class LandingScreen extends StatefulWidget {
  @override
  _LandingScreenState createState() => _LandingScreenState();
}

class _LandingScreenState extends State<LandingScreen> with TickerProviderStateMixin {
  TabController _tabController;
  CovidAPIService covidAPIService = CovidAPIService();
  var covidStatsData;

  Future<Map<String, dynamic>> _getCity() async {
    final String response = await rootBundle.loadString('assets/data/cities.json');
    final Map<String, dynamic> data = await json.decode(response);
    return data;
  }

  Future _getCovidStats() async {
    var data = covidAPIService.get(endpoint: "/reports/total", query: {"date": "2020-04-07"});
    covidStatsData = data;
    return data;
  }

  @override
  void initState() {
    super.initState();
    _getCovidStats();
    _tabController = TabController(length: 2, vsync: this);
  }

  @override
  void dispose() {
    _tabController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        bottomNavigationBar: TabBar(
          controller: _tabController,
          labelColor: Colors.teal.shade700,
          unselectedLabelColor: Colors.tealAccent.shade700,
          indicatorColor: Colors.teal,
          tabs: [
            Tab(
              icon: Icon(Icons.home_rounded),
              child: Text("Home"),
            ),
            Tab(
              icon: Icon(Icons.location_city_rounded),
              child: Text("Location"),
            ),
          ],
        ),
        appBar: AppBar(
          title: Text("Covid 19"),
          centerTitle: true,
        ),
        body: TabBarView(
          controller: _tabController,
          children: [
            _tab1Page(),
            _tab2Page(),
          ],
        ),
      ),
    );
  }

  Widget _tab1Page() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            FutureBuilder<Object>(
                future: null,
                builder: (context, snapshot) {
                  return StatsWidget(
                    yourCity: "İstanbul",
                    testCount: 3000,
                    caseCount: 1000,
                    patientCount: 300,
                    infectedCount: 200,
                    deathCount: 100,
                    healingCount: 400,
                  );
                }),
          ],
        ),
      ),
    );
  }

  Widget _tab2Page() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: FutureBuilder<dynamic>(
        future: _getCity(),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return ListView.separated(
              itemCount: snapshot.data.length,
              separatorBuilder: (BuildContext context, int index) {
                return Divider(
                  color: Colors.tealAccent.shade700,
                  thickness: 2,
                );
              },
              itemBuilder: (BuildContext context, int index) {
                return TextButton(
                  onPressed: () {},
                  style: ButtonStyle(
                    alignment: Alignment.centerLeft,
                    foregroundColor: MaterialStateProperty.all(Colors.teal.shade900),
                    textStyle: MaterialStateProperty.all(
                      TextStyle(
                        fontSize: 28,
                      ),
                    ),
                  ),
                  child: Text(snapshot.data['${index + 1}']),
                );
              },
            );
          } else {
            return Center(
              child: Text("Daha sonra tekrar deneyiniz!.."),
            );
          }
        },
      ),
    );
  }
}
