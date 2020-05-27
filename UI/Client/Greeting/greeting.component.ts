import { Component } from '@angular/core';

import * as signalR from '@microsoft/signalr';

@Component({
  templateUrl: 'greeting.component.html',

})
export class GreetingComponent {
  greeting: string;

  async ngOnInit() {
    let connection = new signalR.HubConnectionBuilder()
      .withUrl("/greetingHub")
      .build();

    connection.on("ReceiveGreeting", data => {
      this.greeting = data;
    });

    await connection.start()
    connection.invoke("SendMessage", "Joe");
  }
}