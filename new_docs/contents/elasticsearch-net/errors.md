---
template: layout.jade
title: Quick Start
menusection: 
menuitem: esnet-errors
---

# Errors

`Elasticsearch.Net` will not throw if it gets an http response other then 200 from Elasticsearch. The response object's `Success` property will be false and `.Error` will contain information on the failed response.

You can throw custom exceptions if you need too by specifying a custom connectionhandler

    var settings = new ConnectionConfiguration()
        .SetConnectionStatusHandler(r=> {
            if (r.HttpStatusCode == 403)
               throw new MyApplicationNotLoggedInException();
            });


## Exceptions

If a request has been retried the maximum amount of times a `MaxRetryException` is thrown. Note that requests are only retried when elasticsearch responds with a `503` or an unspecified connection exception (i.e timeout) has occured on a node. 

`MaxRetryException` will hold the original exception as `.InnerException`.


