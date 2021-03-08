import React, { Component } from 'react';
import { Route, BrowserRouter as Router } from 'react-router-dom'
import Search from './Search';

export default function Home() {
    const [keyword, setKeyword] = React.useState("");
    const [url, setUrl] = React.useState("");
  
    const Button = () => (
        <Router>
        <Route render={({ history }) => (
          <button
            variant="primary"
            type='button'
            onClick={() => { history.push('/search') }}>
            Search
          </button>
        )} />
        <Route exact path="/search/" render={(props) => <Search query={keyword} url={url} {...props} /> } />
        </Router>
      )
  
    return (
      <form>
        <h1>InfoTrack</h1>
        <label>
          Keyword:
          <input
            className="col-md-6"
            name="keyword"
            type="keyword"
            value={keyword}
            onChange={e => setKeyword(e.target.value)}
            required />
        </label>
        
        <label>
          Url:
          <input
            className="col-md-6"
            name="url"
            type="url"
            value={url}
            onChange={e => setUrl(e.target.value)}
            required />
        </label>  
        <Button variant="primary" onClick={Button}>
                </Button>
      </form>
    );
  }
