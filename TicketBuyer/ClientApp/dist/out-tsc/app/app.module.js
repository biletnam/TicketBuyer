"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var auth_service_1 = require("./services/auth.service");
var user_service_1 = require("./services/user.service");
var order_service_1 = require("./services/order.service");
var event_service_1 = require("./services/event.service");
var place_service_1 = require("./services/place.service");
var about_service_1 = require("./services/about.service");
var app_component_1 = require("./components/app/app.component");
var top_navigation_component_1 = require("./components/top-navigation/top-navigation.component");
var main_component_1 = require("./components/main/main.component");
var sign_in_component_1 = require("./components/sign-in/sign-in.component");
var sign_up_component_1 = require("./components/sign-up/sign-up.component");
var profile_component_1 = require("./components/profile/profile.component");
var wish_events_component_1 = require("./components/wish-events/wish-events.component");
var orders_component_1 = require("./components/orders/orders.component");
var add_event_component_1 = require("./components/add-event/add-event.component");
var events_component_1 = require("./components/events/events.component");
var view_event_component_1 = require("./components/view-event/view-event.component");
var event_comments_component_1 = require("./components/event-comments/event-comments.component");
var places_component_1 = require("./components/places/places.component");
var view_place_component_1 = require("./components/view-place/view-place.component");
var add_place_component_1 = require("./components/add-place/add-place.component");
var about_component_1 = require("./components/about/about.component");
var StatusFilter_1 = require("./filters/StatusFilter");
var TypesPipe_1 = require("./filters/TypesPipe");
var appRoutes = [
    { path: '', redirectTo: 'main', pathMatch: 'full' },
    { path: 'main', component: events_component_1.EventsComponent },
    { path: 'sign-in', component: sign_in_component_1.SignInComponent },
    { path: 'sign-up', component: sign_up_component_1.SignUpComponent },
    { path: 'profile', component: profile_component_1.ProfileComponent },
    { path: 'add-event', component: add_event_component_1.AddEventComponent },
    { path: 'view-event/:id', component: view_event_component_1.ViewEventComponent },
    { path: 'places', component: places_component_1.PlacesComponent },
    { path: 'view-place/:id', component: view_place_component_1.ViewPlaceComponent },
    { path: 'add-place', component: add_place_component_1.AddPlaceComponent },
    { path: 'about', component: about_component_1.AboutComponent }
];
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        declarations: [
            app_component_1.AppComponent,
            top_navigation_component_1.TopNavigationComponent,
            main_component_1.MainComponent,
            sign_in_component_1.SignInComponent,
            sign_up_component_1.SignUpComponent,
            profile_component_1.ProfileComponent,
            wish_events_component_1.WishEventsComponent,
            orders_component_1.OrdersComponent,
            add_event_component_1.AddEventComponent,
            events_component_1.EventsComponent,
            view_event_component_1.ViewEventComponent,
            event_comments_component_1.EventCommentsComponent,
            places_component_1.PlacesComponent,
            view_place_component_1.ViewPlaceComponent,
            add_place_component_1.AddPlaceComponent,
            about_component_1.AboutComponent,
            StatusFilter_1.StatusFilter,
            TypesPipe_1.TypesPipe
        ],
        imports: [
            router_1.RouterModule.forRoot(appRoutes, { enableTracing: true }),
            platform_browser_1.BrowserModule,
            http_1.HttpModule,
            forms_1.ReactiveFormsModule,
            forms_1.FormsModule
        ],
        providers: [auth_service_1.AuthService, user_service_1.UserService, order_service_1.OrderService, event_service_1.EventService, place_service_1.PlaceService, about_service_1.AboutService],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map