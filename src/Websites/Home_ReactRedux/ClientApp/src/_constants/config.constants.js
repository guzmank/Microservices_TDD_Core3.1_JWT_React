const prod = {
    url: {
        //API_URL: 'http://localhost:85', // Local
        API_URL: 'http://home.wcf.northjournal.net', // Server 
    }
};

const dev = {
    url: {
        API_URL: 'http://localhost:6001' // Web.Home.Gateway.WebApi
        //API_URL: 'http://localhost:6011' // Home.Identity.WebApi
        //API_URL: 'http://localhost:6012' // Home.WebApi
        //API_URL: 'http://localhost:5002'
        //API_URL: 'http://localhost:85'
    }
};

export const configConstants = process.env.NODE_ENV === 'development' ? dev : prod;
