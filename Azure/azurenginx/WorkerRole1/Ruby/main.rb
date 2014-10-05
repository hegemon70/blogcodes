require 'sinatra'
set :environment, :development
set :port, 1338
get '/' do
  "Hello, my name is Sinatra"
end