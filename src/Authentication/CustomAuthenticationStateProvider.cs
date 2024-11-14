﻿using MauiHybridAuthentication.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MauiHybridAuthentication.Authentication;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticationService _authenticationService;
    private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var authenticationState = new AuthenticationState(_anonymous);

        var userSession = await _authenticationService.GetUserSession();
        if (userSession is not null) 
        {
            var claimsPrincipal = GetClaimsPrincipal(userSession);
            authenticationState = new AuthenticationState(claimsPrincipal);
        }

        return authenticationState;
    }

    public async Task UpdateAuthenticationState(UserSession? userSession, bool rememberUser = false)
    {
        ClaimsPrincipal claimsPrincipal = _anonymous;

        if(userSession is not null)
        {
            if(rememberUser)
                await _authenticationService.SaveUserSession(userSession);
            claimsPrincipal = GetClaimsPrincipal(userSession);
        }
        else
        {
            _authenticationService.RemoveUserSession();
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    private ClaimsPrincipal GetClaimsPrincipal(UserSession userSession)
    {
        return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, userSession.UserName!),
            new Claim(ClaimTypes.Role, userSession.Role!)
        }, "CustomAuth"));
    }
}
