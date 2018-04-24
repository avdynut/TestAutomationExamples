
import scala.concurrent.duration._

import io.gatling.core.Predef._
import io.gatling.http.Predef._
import io.gatling.jdbc.Predef._

class RecordedSimulation extends Simulation {

	val httpProtocol = http
		.baseURL("http://computer-database.gatling.io")
		.inferHtmlResources()
		.acceptHeader("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8")
		.acceptEncodingHeader("gzip, deflate")
		.acceptLanguageHeader("en-US,en;q=0.5")
		.userAgentHeader("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:59.0) Gecko/20100101 Firefox/59.0")

	val headers_0 = Map("Upgrade-Insecure-Requests" -> "1")

	var number = 1

	val scn = scenario("RecordedSimulation")
		.exec(session => {
      session.set("CompName", "My Comp " + number)
			number += 1
      println("CompName: " + session("CompName").as[String])
      session
		})
		.exec(http("Home")
			.get("/")
			.headers(headers_0))
		.pause(4)
		.exec(http("Add a computer")
			.get("/computers/new")
			.headers(headers_0))
		.pause(12)
		.exec(http("Create a computer")
			.post("/computers")
			.headers(headers_0)
			.formParam("name", "${CompName}")
			.formParam("introduced", "")
			.formParam("discontinued", "")
			.formParam("company", "4"))
		.pause(5)
		.exec(http("Search")
			.get("/computers?f=My+Comp")
			.headers(headers_0))
		.pause(2)
		.exec(http("Open")
			.get("/computers/1228")
			.headers(headers_0))
		.pause(3)
		.exec(http("Delete")
			.post("/computers/1228/delete")
			.headers(headers_0))

	setUp(scn.inject(atOnceUsers(2)))
		.protocols(httpProtocol)
		.assertions(global.successfulRequests.percent.gt(95))
}
