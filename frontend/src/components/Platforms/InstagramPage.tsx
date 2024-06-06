'use client';

import UserDetails from './UserDetails';
import InstagramPostForm from './InstagramPostForm';

export default function InstagramPage() {

  return (
    <div className="h-full flex flex-col">
      <UserDetails className="ml-4" />
      <div className="h-full flex justify-center items-center">
        <InstagramPostForm />
      </div>
    </div>
  );
}
