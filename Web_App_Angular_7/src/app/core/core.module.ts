import { NgModule, Optional, SkipSelf } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './interceptors';
import { RouterModule } from '@angular/router';
import { EnsureModuleLoadedOnceGuard } from './ensure-module-loaded-once.guard';
import { GrowlerModule } from './growler/growler.module';
import { NavbarModule } from './navbar/navbar-module';
import { EventBusService } from './services/event-bus.service';
import { UserAuthenticationService } from './services/user-authentication.service';
import { LoggerService } from './services/logger.service';


@NgModule({
  imports: [RouterModule, HttpClientModule, GrowlerModule, NavbarModule],
  exports: [RouterModule, GrowlerModule, NavbarModule],
  declarations: [],
  providers: [
    EventBusService,
    UserAuthenticationService,
    LoggerService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ]
})
export class CoreModule extends EnsureModuleLoadedOnceGuard {
  // Ensure that CoreModule is only loaded into AppModule

  // Looks for the module in the parent injector to see if it's already been loaded (only want it loaded once)
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    super(parentModule);
  }
}
