var SayHello = React.createClass({
    render: function() {
        return <div>Hello!!</div>;
    }
});

var ErrorMessage = React.createClass({
    render:function() {
        return <li> {this.props.error}</li>
    }
});


var Login = React.createClass({

    getInitialState: function() {
        return {
            username: '',
            password: ''
        };
    },

    handleChange: function (name, e) {
        var change = {};
        change[name] = e.target.value;
        this.setState(change);
    },

    handleSubmit: function(e) {
        e.preventDefault();
        this.props.onLogedin(this);
    },

    render: function() {
        return (
            <div>
                <h3>Login</h3>
                <form onSubmit={this.handleSubmit}>
                    <input onChange={this.handleChange.bind(this, 'username')} value={this.state.username} />
                    <input onChange={this.handleChange.bind(this, 'password')} type="password" value={this.state.password} />
                    <button>sign in</button>
                </form>
            </div>
            );
}
});

    var Demo = React.createClass({

    getInitialState: function() {
        return {showLogin:true};
    },

    onLogedin: function(obj) {
        var userModel = {
            "username": obj.state.username,
            "password": obj.state.password
        };

        $.ajax({
            type: 'POST',
            contentType: "application/json",
            url: 'http://localhost:22103/api/customlogin',
            data: JSON.stringify(userModel),
            success: function(data) {
                sessionStorage.setItem('superToken', data.authenticationToken);
                this.setState({showLogin: false});
            }.bind(this),
            error: function() {
                React.render(<ErrorMessage error="Invalid login attempt"/>, document.getElementById('errorlog'));
            }.bind(this)
        });
    },

    render: function() {
        return (
            <div>
                { this.state.showLogin ? <Login onLogedin={this.onLogedin } /> : null }
                { this.state.showLogin ? null : <SayHello /> }
            </div>
            );
}
});

React.render(<Demo />, document.getElementById('demo'));